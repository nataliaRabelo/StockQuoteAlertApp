namespace StockQuoteAlertApp.Configuration
{
    /// <summary>
    /// Representa as configurações de e-mail utilizadas para enviar notificações.
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// Obtém ou define a lista de e-mails dos destinatários para os quais as notificações serão enviadas.
        /// </summary>
        public string RecipientEmails { get; set; }
        /// <summary>
        /// Obtém ou define o servidor de e-mail usado para o envio de notificações.
        /// </summary>
        public string MailServer { get; set; }
        /// <summary>
        /// Obtém ou define a porta usada pelo servidor de e-mail.
        /// </summary>
        public int MailPort { get; set; }
        /// <summary>
        /// Obtém ou define o nome do remetente que aparecerá nos e-mails de notificação.
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// Obtém ou define o endereço de e-mail do remetente.
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// Obtém ou define a senha do e-mail do remetente, usada para autenticação no servidor de e-mail.
        /// </summary>
        public string Password { get; set; }
    }
}
