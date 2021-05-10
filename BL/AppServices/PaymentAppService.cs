using AutoMapper;
using BL.Bases;
using BL.ViewModel;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL.AppServices
{
    public class PaymentAppService : AppServiceBase
    {
        public List<PaymentViewModel> GetAllPayments()
        {
            return Mapper.Map<List<PaymentViewModel>>(TheUnitOfWork.Payment.GetAllPayment());
        }
        public List<PaymentViewModel> GetPaymentsOfUser(string id)
        {

            return GetAllPayments().Where(p => p.userID == id).ToList();
        }
        public PaymentViewModel GetPayment(int id)
        {
            return Mapper.Map<PaymentViewModel>(TheUnitOfWork.Payment.GetById(id));
        }

        public bool SaveNewPayment(PaymentViewModel paymentViewModel)
        {

            bool result = false;
            var payment = Mapper.Map<Payment>(paymentViewModel);
            if (TheUnitOfWork.Payment.Insert(payment))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool UpdatePayment(PaymentViewModel paymentViewModel)
        {
            var payment = Mapper.Map<Payment>(paymentViewModel);
            TheUnitOfWork.Payment.Update(payment);
            TheUnitOfWork.Commit();
            return true;
        }

        public bool DeletePayment(int id)
        {
            bool result = false;
            TheUnitOfWork.Payment.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckPaymentExists(PaymentViewModel paymentViewModel)
        {
            Payment payment = Mapper.Map<Payment>(paymentViewModel);
            return TheUnitOfWork.Payment.CheckPaymentExists(payment);
        }
    }
}
