﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffizyMusicSystem.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string recipientEmail, string subject, string message);
        Task SendApprovalEmailAsync(string recipientEmail);
        Task SendRejectionEmailAsync(string recipientEmail);

    }
}
