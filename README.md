# Tutorial para Implementar Oauth en una solución WebApi con Identity 2.1

#### Autor:
> Victor Cornejo , rex2002xp (at) gmail (dot) com

#### Licencia:
> Creative Commons

####Aclaración
* He tomado como referencia los excelentes artículos publicados por Taiseer Joudeh sobre el tema, la única intención es facilitar el acceso de esta información en el idioma Español. En ningún momento deseo acreditarme o plagiar el excelente trabajo que Taiseer realiza en su blog. Te invito a revisar su blog en [bitoftech.net] no te arrepentirás.

####Objetivo
Para esta solución he tomado como base el código fuente que se genero en el repositorio [AspNetIdentity2.1.WebApi.sendConfirmation] , de esta forma podemos reutilizarlo y ampliar las funcionalidades.

En esta ocasión cubriremos las siguientes funcionalidades:
* Implementacion de Autenticacion por medio de un Token tipo Bearer, enviando usuario y clave al servidor.
* Implementacion de Autorizacion utilizando JWT (Json Web Token) [1].




[AspNetIdentity2.1.WebApi.sendConfirmation]:https://github.com/rex2002xp/AspNetIdentity2.1.WebApi.sendConfirmation
[bitoftech.net]:http://bitoftech.net/
[1]:http://jwt.io/