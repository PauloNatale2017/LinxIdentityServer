# LinxIdentityServer
Teste para FullStack Developer

RESUMO
Para resolução das especificações do teste proposto, efetuei a criação de um servidor de autenticação para todo e qualquer acesso efetuado em qualquer parte do sistema de aplicação. O servidor de autenticação utiliza a tecnologia IdentityServer3 usando (Token,Certificado Digital,Reconhecimento de aplicações e criptografia de 32 byts), sempre que houver um acesso a aplicação, ou seus métodos, ou suas paginas mediante configuração ele sempre solicitara um token, autenticado para hierarquização de nível de acesso baseado por Claims e Roles. A aplicação identificara o se o usuário já esta autenticado e seus acessos, do contrario ira redirecionar o mesmo para uma nova autenticação caso seu acesso já tenha expirado.


INSTALAÇÃO
Efetuar o download dos projetos e do script de criação de base
LinxIdentityServer, Linx.Application, BANCO-LINX
Primeiro executar o script, os packages estão na aplicação assim que efetuar seu primeiro build a aplicação já efetuara o download das dlls necessárias.
Executar o projeto LinxIdentityServer e deixar rodando ele sera nosso servidor a primeira tela utiliza um layout padrão da api.
 
Executar o projeto Linx.Application essa será nossa aplicação Web onde será autenticada em nosso servidor. A primeira tela exibe apenas uma opção que não requer autenticação. 
 


Seu único acesso redireciona para o site da empresa 
 




Click em “Autenticação de Usuarios - Linx” esse botão faz com que sua aplicação seja redirecionada para nosso servidor de autenticação.
 
Em nossa base foram configurados 3 niveis de acessos diferente sendo eles admin,cliente e user. Cada usuário possue um nível de acesso diferente estabelecido sempre após a autenticação do mesmo no servidor.



Usuário: admin,Senha:123
 
Usuário: user,Senha:123
  Usuário: cliente,Senha:123
 
Dados de acesso para “Admin”
 O usuário admin possui acesso a todos os módulos dentro da aplicação

Dados de acesso para “Cliente”
  O usuário Cliente possui acesso restrito a determinadas informações dentro dos  módulos  da aplicação



Dados de acesso para “User”
  O usuário User possui acesso restrito a determinadas informações dentro dos  módulos  da aplicação

Cada modulo exibe uma informação diferente acessadas através de um repositório dinâmico, utilizando injeção de dependência para garantir menor dependência entre seus módulos, garantindo maior integridade de seu fluxo.

Dados de cada modulos 

   
