// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PasswordDigestMessageInspector.cs" company="Rebecca Powell">
//  Copyright 2008-2014 Rebecca Powell.
//  Distributed under the terms of the GNU General Public License.
// </copyright>
// <summary>
//  Demonstration code that implements the Turnstile HelloService
//  client proxy and attaches the custom PasswordDigestBehavior
// </summary>
// <disclaimer>
//  The sample code described herein is provided on an "as is" basis, 
//  without warranty of any kind, to the fullest extent permitted by law. We do not warrant, 
//  guarantee or make any representations regarding the use, results of use, accuracy, timeliness 
//  or completeness of any data or information relating to the sample code. We shall not be liable 
//  for any direct, indirect or consequential damages or costs of any type arising out of any action 
//  taken by you or others related to the sample code.
// </disclaimer>
// --------------------------------------------------------------------------------------------------------------------

namespace Turnstile.Extensions
{
    using System;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Dispatcher;
    using System.Xml;

    using Microsoft.Web.Services3.Security.Tokens;

    /// <summary>
    /// Custom ClientMessageInspector to modify the message before it is sent
    /// and include a Hashed Password Digest UsernameToken in accordance to 
    /// the WS-I Basic Profile Security profile. The item shall be added to the
    /// SOAP request headers.
    /// </summary>
    public class PasswordDigestMessageInspector : IClientMessageInspector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordDigestMessageInspector" /> class.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public PasswordDigestMessageInspector(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        #region IClientMessageInspector Members

        /// <summary>
        /// The after receive reply.
        /// </summary>
        /// <param name="reply">The reply.</param>
        /// <param name="correlationState">The correlation state.</param>
        /// <exception cref="NotImplementedException">This method is not implemented.</exception>
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The before send request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="channel">The channel.</param>
        /// <returns>
        /// The <see cref="object" />.
        /// </returns>
        public object BeforeSendRequest(ref Message request, System.ServiceModel.IClientChannel channel)
        {
            // Use the WSE 3.0 security token class
            var token = new UsernameToken(this.Username, this.Password, PasswordOption.SendHashed);

            // Serialize the token to XML
            var securityToken = token.GetXml(new XmlDocument());

            // build the security header
            var securityHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", securityToken, false);
            request.Headers.Add(securityHeader);

            // complete
            return Convert.DBNull;
        }

        #endregion
    }
}
