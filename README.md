Sistema de Gestão Hospitalar - Saúde++
Sobre o Projeto
Saúde++ é um sistema de gestão hospitalar desenvolvido como Projeto de Conclusão de Curso de Técnico em Informática. A aplicação foi criada para solucionar desafios no ambiente hospitalar, promovendo uma maior integração entre pacientes e médicos.

O sistema centraliza todas as informações do paciente em um único local de fácil acesso, além de oferecer módulos para gerenciar o cadastro de pacientes, médicos, fornecedores e o controle de estoque do hospital.

Funcionalidades Principais
Gestão de Pacientes: Cadastro e consulta de informações completas dos pacientes.

Gestão de Médicos/Funcionários: Cadastro e controle de acesso para a equipe do hospital.

Controle de Estoque: Gerenciamento de produtos e medicamentos.

Cadastro de Fornecedores: Centralização de informações dos fornecedores.

Centralização de Dados: Permite que o paciente insira e acesse seus dados, facilitando a comunicação com a equipe médica.

Tecnologias Utilizadas
Linguagem: C# (.NET Framework)

Interface: Windows Forms

Banco de Dados: MySQL

Guia de Instalação e Configuração
Para executar este projeto em sua máquina local, siga os passos abaixo.

1. Pré-requisitos
Antes de começar, você precisará ter os seguintes softwares instalados:

Visual Studio: Versão 2017 ou mais recente, com a carga de trabalho ".NET Desktop Development".

MySQL Server: O banco de dados onde todas as informações serão armazenadas.

Faça o download através do MySQL Installer.

Durante a instalação, anote a senha que você definir para o usuário root.

MySQL Workbench: Uma ferramenta visual para gerenciar seu banco de dados (geralmente incluída no MySQL Installer).

2. Configuração do Banco de Dados
O programa precisa de um banco de dados e tabelas específicas para funcionar.

Abra o MySQL Workbench e conecte-se ao seu servidor local usando o usuário root e a senha que você definiu.

Copie todo o conteúdo do arquivo script_banco.sql (disponível neste repositório).

Cole o script em uma nova janela de query no Workbench e execute-o clicando no ícone de raio (⚡).

Isso criará o banco de dados Saude e todas as tabelas necessárias (tblClientes, tblFunc, etc.).

3. Configuração do Projeto
Clone o Repositório:

git clone https://github.com/seu-usuario/seu-repositorio.git

Ou faça o download do projeto como um arquivo .zip. Se fizer o download como .zip, clique com o botão direito sobre ele, vá em Propriedades e marque a caixa "Desbloquear" antes de extrair.

Abra o Projeto no Visual Studio:

Navegue até a pasta do projeto e abra o arquivo de solução (Saude.sln).

Configure a Conexão com o Banco de Dados (Passo Crucial):

No Gerenciador de Soluções, encontre e abra o arquivo App.config.

Localize a linha que começa com <add name="Saude.Properties.Settings.saudeConnectionString"....

Edite a connectionString, substituindo SUA_SENHA_AQUI pela senha do seu usuário root do MySQL.

Exemplo:

<add name="Saude.Properties.Settings.saudeConnectionString" 
     connectionString="server=localhost;user id=root;password=SUA_SENHA_AQUI;persistsecurityinfo=True;database=Saude" 
     providerName="MySql.Data.MySqlClient" />

4. Compilar e Executar
No Visual Studio, certifique-se de que todas as dependências do NuGet foram restauradas (geralmente acontece automaticamente ao abrir o projeto).

Vá ao menu Compilar (Build) > Recriar Solução (Rebuild Solution).

Pressione F5 ou clique no botão "Iniciar" (▶️) para executar o programa.

Se todos os passos foram seguidos corretamente, a tela de login ou o menu principal do sistema deverá aparecer.

Contribuição
Este é um projeto acadêmico, mas sugestões e melhorias são sempre bem-vindas. Sinta-se à vontade para abrir uma issue ou enviar um pull request.
