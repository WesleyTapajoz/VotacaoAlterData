
<h1 id="bem-ao-sistema-de-votação-alterdata">Bem ao Sistema de Votação AlterData!</h1>
<p>Devido ao grande volume de pedidos de recursos que a Alterdata recebe<br>
todos os dias, a equipe de desenvolvimento não consegue desenvolver todos ao<br>
mesmo tempo. A diretoria teve uma ideia de desenvolver um sistema de votação,<br>
em que todas as filiais poderão votar nos recursos que são mais importantes para<br>
os clientes. Os recursos mais votados serão priorizados pela equipe de<br>
desenvolvimento.</p>
<h1 id="requisitos-para-execução-do-projeto">Requisitos para execução do projeto</h1>
<p>Para o visual studio code.<br>
1-Instalar .Net FrameWork Core disponivel em <a href="https://dotnet.microsoft.com/download">https://dotnet.microsoft.com/download</a></p>
<h2 id="etapas-para-execução-do-projeto">Etapas para execução do projeto</h2>
<p>1- Abra seu editor visual studio code no diretorio <strong>C:\VotacaoAlterData</strong><br>
2- Abra 1 terminal no seu editor visual studio code.<br>
3- Aponte 1 para o projeto. <strong>C:\Git\VotacaoAlterData\VotacaoAlterData.Repository&gt;</strong><br>
4- Execute a seguinte linha de comando <strong>dotnet ef --startup-project …/VotacaoAlterData.WebAPI migrations add init</strong> após a execução concluida, execute o segundo comando.<br>
<strong>dotnet ef --startup-project …/VotacaoAlterData.WebAPI database update</strong> após concluido feche o terminal.<br>
5- Abra 2 terminais no seu editor visual studio code.<br>
6- Aponte 1 terminal para o projeto. <strong>C:\Git\VotacaoAlterData\VotacaoAlterData.WebAPI&gt;</strong><br>
7- Execute o comando <strong>dotnet watch run</strong> .<br>
8- Aponte o segundo para o projeto. C:\Git\VotacaoAlterData\VotacaoAlterData-App&gt; Execute o comando <strong>npm i</strong> .<br>
9- Após a execução, execute <strong>ng serve</strong> .</p>
<h1 id="framework-e-banco-de-dados">Framework E Banco de dados</h1>
<p>Angular 10. * . *<br>
EntityFrameworkCore ^3<br>
Bootstrap ^4<br>
AutoMapper ^10<br>
Swashbuckle.AspNetCore ^5<br>
Microsoft.AspNetCore.Identity<br>
Npgsql.EntityFrameworkCore.PostgreSQL ^3</p>
<h1 id="banco-de-dados">Banco de dados</h1>
<p>Postgres ^10</p>
<h1 id="linguagem">Linguagem</h1>
<p>C#</p>
<h1 id="rquitetura">Arquitetura</h1>
<p>DDD</p>
<h1 id="padrao">Padrão</h1>
<p>Repository</p>

