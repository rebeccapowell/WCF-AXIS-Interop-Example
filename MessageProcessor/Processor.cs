// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Processor.cs" company="Rebecca Powell">
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

namespace MessageProcessor
{
    using Turnstile.Amce.v1;
    using Turnstile.Extensions;

    /// <summary>
    /// Demonstration code that implements the Turnstile HelloService 
    /// client proxy and attaches the custom PasswordDigestBehavior
    /// </summary>
    public class Processor
    {
        /// <summary>
        /// The send hello method.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string SendHello(string firstName)
        {
            // Client Proxy
            var client = new Hello_PortTypeClient("Hello_Binding");

            // Add custom behavior
            var behavior = new PasswordDigestBehavior("Username", "Password");
            client.Endpoint.Behaviors.Add(behavior);

            // Say hello
            return client.sayHello(null, firstName);
        }
    }
}
