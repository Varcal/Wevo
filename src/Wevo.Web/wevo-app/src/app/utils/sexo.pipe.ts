import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'sexo'
})
export class SexoPipe implements PipeTransform{
    transform(sexo, args){
        if(sexo == 1) return 'Masculino';
        if(sexo == 2) return 'Feminino';
    }
}