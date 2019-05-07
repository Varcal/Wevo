using Wevo.Dominio.Contratos.Transacoes;
using Wevo.NucleoCompartilhado.DomainEvents.Core;
using Wevo.NucleoCompartilhado.DomainEvents.Notifications;

namespace Wevo.Dominio.Servicos
{
    public abstract class ServicoBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotificationHandler _notificationsHandler;

        protected ServicoBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _notificationsHandler = (IDomainNotificationHandler)DomainEvent.ServiceProvider.GetService(typeof(IDomainNotificationHandler));
        }

        protected void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }

        protected void Commit()
        {
            _unitOfWork.Commit();
        }

        protected void Rollback()
        {
            _unitOfWork.Rollback();
        }


        protected void Save()
        {
            if(_notificationsHandler.HasNotification()) return;

            _unitOfWork.Save();
        }
    }
}
