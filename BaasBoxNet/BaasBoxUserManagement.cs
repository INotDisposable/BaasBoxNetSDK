﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BaasBoxNet.Models;

namespace BaasBoxNet
{
    public sealed class BaasBoxUserManagement
        : IBaasBoxUserManagement
    {
        private readonly BaasBox _box;

        internal BaasBoxUserManagement(BaasBox box)
        {
            _box = box;
        }

        public bool IsAuthenticated
        {
            get { return _box.User != null && !string.IsNullOrWhiteSpace(_box.User.Session); }
        }

        public Task<BaasUser> SignupAsync(string username, string password)
        {
            var requestBody = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            return _box.RestService.PostAsync<BaasUser>("user", requestBody);
        }

        public Task<BaasUser> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task ChangePasswordAsync(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}