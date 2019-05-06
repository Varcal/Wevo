import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'phone'
})

export class PhonePipe implements PipeTransform
{
    transform(tel, args)
    {
        var value = tel.toString().trim().replace(/^\+/, '');

        if (value.match(/[^0-9]/)) {
            return tel;
        }

        var country, city, number;

        switch (value.length) {
            case 10: // +1PPP####### -> (PP) ####-####
                country = 1;
                city = value.slice(0, 2);
                number = value.slice(2);
                break;

            case 11: // +CPPP####### -> (PP) #####-####
                country = 1;
                city = value.slice(0, 2);
                number = value.slice(2);
                break;
            default:
                return tel;
        }

        if (country == 1) {
            country = "";
        }

        number = number.slice(0, 5) + '-' + number.slice(5);

        return (country + " (" + city + ") " + number).trim();
    }
}