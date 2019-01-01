# DigiBank


Orientações para rodar o projeto.<br />

1 - Após baixá-lo, deve ser copiado o Diretório DigiEnv para C:\DigiEnv<br />

Dentro da pasta DigiEnv existem 3 arquivos.<br />
-Certificado digital utilizado para geração do token.<br />
-Arquivo compartilhado entre as API (SharedappSettings)<br />
-Arquivo utilizado para Xunit Test (appSettings)<br />

2 - Executar o script para criar o banco.


Este projeto tem como proposta redução de código fonte, baixo acoplamento entre classes e delimitacao de responsabilidades entre camadas.

-Para redução de código foi aplicada herança de classes genéricas:
*Crud
*AutoMapper.
*Serviços da aplicação
*Controller, mas foi utilizada apenas na controller de cliente como exemplo.
*Projeto Unit Test.

-A utilização de injeção além de manter baixo acoplamento entre as classes, facilita na criacao do modelo de testes.

-O projeto foi baseada na arquiteruta de camadas DDD com a finalidade de demilitar as responsabilidades entre camadas. 
