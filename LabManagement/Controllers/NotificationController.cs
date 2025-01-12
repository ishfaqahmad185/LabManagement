using LabManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace LabManagement.Controllers
{
    public class NotificationController : Controller
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult SendAppointmentReminder(string patientPhone, string appointmentDetails)
        {
            string message = $"Reminder: {appointmentDetails}";
            _notificationService.SendSms(patientPhone, message);
            return View("NotificationSent");
        }

        public IActionResult SendTestResultNotification(string patientEmail, string resultDetails)
        {
            string subject = "Your Test Result is Ready";
            string body = $"Dear patient, your test result is now available: {resultDetails}";
            _notificationService.SendEmail(patientEmail, subject, body);
            return View("NotificationSent");
        }

        public IActionResult SendPaymentReceipt(string patientEmail, string paymentDetails)
        {
            string subject = "Payment Receipt";
            string body = $"Dear patient, your payment was successful: {paymentDetails}";
            _notificationService.SendEmail(patientEmail, subject, body);
            return View("NotificationSent");
        }
    }

}
