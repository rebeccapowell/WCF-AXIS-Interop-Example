![Logo](https://repository-images.githubusercontent.com/26542398/a7ea4a00-3303-11eb-9d28-1cda9680fdd1)

License
=================================
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.


Disclaimer
=================================
The sample code described herein is provided on an "as is" basis, 
without warranty of any kind, to the fullest extent permitted by law. We do not warrant, 
guarantee or make any representations regarding the use, results of use, accuracy, timeliness 
or completeness of any data or information relating to the sample code. We shall not be liable 
for any direct, indirect or consequential damages or costs of any type arising out of any action 
taken by you or others related to the sample code.

Purpose
=================================
This Visual Studio.NET 2012 solution demonstrates how you can use MessageInspectors in WCF in
conjunction with custom behaviors, so that you can support the WS-I Basic Profile UsernameToken
with a hashed Password Digest - currently unsupported in WCF.

The approach is as if you have been supplied a WSDL from a third party (Apache Axis2 stack), and
follows through the process of creating the client proxy and overriding the SOAP headers before
the message is sent.
