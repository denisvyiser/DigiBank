# DigiBank


Orientações para rodar o projeto.<br />

1 - Após baixá-lo, deve ser copiado o Diretório DigiEnv para C:\DigiEnv<br />

Dentro da pasta DigiEnv existem 3 arquivos.<br />
-Certificado digital utilizado para geração do token.<br />
-Arquivo compartilhado entre as API (SharedappSettings)<br />
-Arquivo utilizado para Xunit Test (appSettings)<br />

2 - Executar o script para criar o banco.

Script de teste para simulação de transferência está no arquivo abaixo:<br />

DigiBank.Integration.Testing/Scenarios/OperacaoBancariaTest.cs<br />


Este projeto tem como proposta redução de código fonte, baixo acoplamento entre classes e delimitacao de responsabilidades entre camadas.
<br />
-Para redução de código foi aplicada herança de classes genéricas:<br />
*Crud<br />
*AutoMapper.<br />
*Serviços da aplicação<br />
*Controller, mas foi utilizada apenas na controller de cliente como exemplo.<br />
*Projeto Unit Test.<br />

-A utilização de injeção além de manter baixo acoplamento entre as classes, facilita na criacao do modelo de testes.<br />

-O projeto foi baseada na arquiteruta de camadas DDD com a finalidade de demilitar as responsabilidades entre camadas. 


