using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Infrastructure.Data;
using Infrastructure.Services;
using UnityEngine;

namespace Game.Quizzes
{
    public class Final : MonoBehaviour
    {
        private PlayerProgress _playerProgress;

        private void Awake()
        {
            _playerProgress = AllServices.Container.Single<PlayerProgress>();
        }

        public void Send(string email)
        {
            MailMessage message = new MailMessage();
            message.Subject = "Ваши ответы и оценка в тестовой викторине!";
            message.Body = _playerProgress.GetPlayerInfo();
            message.From = new MailAddress("smtp_test_fusion@mail.ru");
            message.To.Add(email);
            message.BodyEncoding = System.Text.Encoding.UTF8;

            SmtpClient client = new SmtpClient();

            client.Host = "smtp.mail.ru";
            client.Port = 587;
            client.Credentials = new NetworkCredential(message.From.Address, "vi5WGhKdg5rQ6GQDNGgp");
            client.EnableSsl = true;
            
            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, errors) => true;
            client.Send(message);
        }
    }
}