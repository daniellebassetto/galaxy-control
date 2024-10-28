# 🚀🌠 GalaxyControl 

**GalaxyControl** é um sistema desenvolvido em C# .NET 8 utilizando o padrão **MVC** para catalogação e acompanhamento de naves caídas e monitoramento de patos galácticos. O sistema foi implantado em uma instância EC2 da AWS, conectando-se a um banco de dados MySQL, e utiliza tecnologias modernas de front-end. O projeto faz parte do desafio DSIN CODER CHALLENGE 2024 e foi desenvolvido no período de 19/10 a 27/10.

---

## ⚙️ Tecnologias Utilizadas 

- **Backend:**
  - C# .NET 8
  - MVC (Model-View-Controller)
  - EntityFramework como ORM

- **Frontend:**
  - HTML5
  - CSS3
  - JavaScript
  - Bootstrap

- **Banco de Dados:**
  - MySQL

- **Infraestrutura:**
  - AWS EC2

---

## 🌐 Arquitetura e Infraestrutura 
A escolha da arquitetura MVC foi estratégica para o projeto, e aqui está o porquê:

✅ Facilidade de Entendimento: O padrão MVC é simples de compreender e estruturar, facilitando a divisão entre o backend e o frontend. <br/>
✅ Integração Eficiente: Ele promove uma interação suave entre o backend e o frontend, tornando o desenvolvimento e a manutenção muito mais ágeis. <br/>
✅ Menor Uso de Recursos: Em comparação com uma arquitetura baseada em API, o MVC exige menos recursos para execução. Usar uma API exigiria escalar backend e frontend separadamente, aumentando a complexidade e introduzindo riscos de falhas de comunicação. No MVC, isso é tudo mais direto e integrado!

Para o deploy, utilizei uma instância EC2 Windows 10 do tipo t3.medium, que oferece o desempenho ideal para garantir que a aplicação funcione com boa disponibilidade. 

🔧 A configuração incluiu a instalação do MySQL para a persistência dos dados e o setup do .NET para o build do projeto. Com o Entity Framework, foi possível gerar o schema do banco de dados de maneira super prática através das migrations, evitando a necessidade de escrever scripts SQL detalhados manualmente!  Além disso, foi necessário criar um IP estático para possibilitar o acesso de forma única (visto que o dinâmico muda).

E porque utilizei MySQL? O MySQL é um banco relacional e isso é muito importante para este projeto, que possui tipagens muito concretas, chaves primárias etc. Ele possui uma ótima integração com o EntityFramework. Mas também poderiam ser utilizados bancos como PostgreSQL, SQL Server etc.

---

## Funcionalidades do Sistema

### 👩🏻‍💻 1. Login e Registro
- **Cadastro:** Os usuários devem se registrar com um e-mail válido.
- **Redefinição de Senha:** Possibilidade de redefinir a senha em caso de esquecimento.
- Assim temos no projeto sessão de usuário logado, evitando que xenófagos possam hackear nosso sistema 

![Tela de login](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20145356.png)

![Tela de Cadastro](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20145409.png)

### 🏠 2. Home e Guia de uso 

![Home](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20145646.png)

![Guia de Uso](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20145933.png)

### 🧑‍🚀🚀 3. Catalogação de Naves 
- **CRUD de Naves:** Criar, editar e excluir naves caídas.
- **Status de Reparo:** Ao criar uma nave, o status é definido como **"Aguardando"** e pode ser alterado para **"Em Andamento"** ou **"Finalizado"**. Naves com status **"Em Andamento"** ou **"Finalizado"** não podem ser editadas ou excluídas.
- **Cálculo de Tripulantes:** O número de sobreviventes é a soma dos feridos e saudáveis.
- **Código de Rastreamento:** Único por nave e não editável.
- **Salvamento Condicional:** O botão de salvar só é habilitado se todos os campos obrigatórios estiverem preenchidos e um uso futuro for definido.

🛠️ Usos Futuros da Nave 
Ao adicionar uma nave caída, com base nos dados informados, o sistema mostra os possíveis usos futuros da nave, sendo que pode ter apenas um ou mais se a nave possuir excelentes atributos. O usuário poderá escolher qual deseja atribuir e será possível editá-lo depois desde que a nave ainda esteja aguardando reparo. As classificações são as seguintes:

- **Sucata Espacial:** nave muito destruída ou com perda total e possui pouco ou nenhum valor tecnológico.
- **Joia Tecnológica:** nave com potencial de prospecção tecnológica alto ou revolucionário.
- **Arsenal Alienígena:** nave com armamento pesado.
- **Ameaça em Potencial:** nave com grau de periculosidade crítico ou alto.
- **Fonte de Energia Alternativa:** nave com combustível de tecnologia alternativa.
- **Mistureba Inconclusiva:** nenhuma classificação anterior atende, significa que é um tipo de nave que mistura várias características mas não é a melhor em uma em específico.

![Listagem de naves](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20150028.png)

![Criação da nave](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20150528.png)

![Escolha da classificação](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20151954.png)

![Edição da nave](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20152041.png)

![Exclusão da nave](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20152215.png)

![Visualização da nave](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20152406.png)

### 🦆 4. Monitoramento de Patos Galácticos 
- **Exibição:** Mostra a distância e imagens dos patos galácticos.
- **Classificação:** Imagens indicam se os patos estão sozinhos, em bando, xenófagos ou normais.
- **Estratégias de Captura:** Ao clicar em um pato, o usuário pode ver estratégias para capturar xenófagos, com base na distância e se estão em bando (total de 8 estratégias).

![Conexão com óculos](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20152505.png)

![Visualização dos patos](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20152605.png)

![Visualização de um pato comum](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20152752.png)

![Visualização de pato xenófago](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20152808.png)

### 🔑 5. Redefinir senha do usuário 

![Redefinição de senha](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20153014.png)

### 🚪 6. Sair do Sistema 

![Sair](https://github.com/daniellebassetto/galaxy-control/blob/f7826da2987c8a33525e20b1291b4a6f906fa29f/Capturas%20de%20tela%20e%20video/Captura%20de%20tela%202024-10-27%20153158.png)

---

## 💻 Rodando o Projeto Localmente
Na documentação entregue, consta os dados para acessar o site através da EC2. Caso a instância EC2 não responda, siga os passos abaixo para executar o projeto localmente:

1. **Pré-requisitos:**
   - .NET SDK 8.0 ou superior
     - [Download do .NET SDK](https://dotnet.microsoft.com/pt-br/download)
   - MySQL Server
     - [Download do MySQL Server](https://dev.mysql.com/downloads/installer/)

2. **Clone o repositório e exlcua a pasta "Capturas de tela e video":**
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd GalaxyControl
   ```

3. **Configurar a String de Conexão:**
   - Abra o arquivo `appsettings.json` e, se necessário, atualize a string de conexão para o seu banco de dados MySQL.

4. **Criar o Banco de Dados:**
   - Execute as migrations para criar o banco de dados. Abra o terminal na pasta do projeto e rode o comando:
   ```bash
   dotnet ef database update
   ```

5. **Instalação das Dependências:**
   ```bash
   dotnet restore
   ```

6. **Executando a Aplicação:**
   ```bash
   dotnet run
   ```
   - Acesse o sistema através do navegador no endereço `http://localhost:5001`.

---

## 📽️ Capturas de Tela e Vídeo

As capturas de tela e o vídeo de apresentação do projeto foram arquivados na pasta "Capturas de tela e video" aqui no repositório. Para acessar o vídeo é necessário realizar o download e extrair o arquivo zip.

---

## 🎓 Lições Aprendidas no Projeto

🔧 Técnicas Aprendidas

- Estudo de Arquitetura

Estudei sobre qual arquitetura seria mais interessante utilizar, pois temos várias e cheguei a conclusão que neste caso a MVC poderia me ajudar mais e entregaria um projeto de qualidade da mesma forma que um projeto com arquitetura mais complexa.

- Deploy na AWS EC2:

Configurei uma instância EC2 t3.medium do zero, otimizando-a para garantir boa disponibilidade e performance. Aprendi a lidar com questões de infraestrutura e deploy.

- Automação com Entity Framework:

Utilizei migrations para automatizar a criação e manutenção do banco de dados, evitando erros manuais.
Ganhei confiança no uso de ferramentas que reduzem trabalho repetitivo e aumentam a produtividade.


🌟 Soft Skills Desenvolvidas
- Capacidade analítica e planejamento:

Desde o início do projeto, antes de começar a desenvolvê-lo, planejei como seriam as entidades, relações etc. Procurei ter uma visão macro para entender possíveis problemas que eu poderia encontrar e isso facilitou muito o desenvolvimento.

- Resolução de Problemas:

Ao configurar a infraestrutura e lidar com possíveis erros durante o deploy, melhorei minha capacidade de encontrar soluções rapidamente e de forma eficaz.

- Gestão do Tempo:

Confesso que gerir o tempo sempre é a questão mais desafiadora! Por isso, utilizei o Trello para colocar cards de cada tarefa que desenvolvia, organizando mais os processos e conseguindo visualizar melhor o que estava pendente e o que já havia sido feito. Para cada atividade desenvolvida era gerada uma pullrequest maior na qual eu revisava novamente antes de mesclar na branch master. Foquei primeiro nos pontos pedidos, que eram os mais importantes, o famoso "MVP (Minimum Viable Product)". Depois, utilizei o tempo restante para desenvolvimento de funcionalidades extras e aprimoramento do software.

---

## 🧼 Conceitos de Clean Code no Projeto

Ao desenvolver o projeto, apliquei diversos princípios de Clean Code para garantir que o código fosse legível, fácil de manter e eficiente. Aqui estão alguns dos conceitos chave que utilizei:

🔁 DRY (Don't Repeat Yourself)
Evite a Repetição de Código: Sempre que possível, reutilizei funções e métodos em vez de duplicar blocos de código. Isso garante que, se houver necessidade de mudanças, elas sejam feitas em um único lugar, reduzindo o risco de erros e inconsistências.

✨ KISS (Keep It Simple, Stupid)
Mantenha o Código Simples: Complexidade excessiva muitas vezes gera problemas. Apliquei o princípio KISS ao buscar sempre a solução mais simples e direta para cada problema. Isso não significa fazer o "mais fácil", mas sim evitar complicações desnecessárias que poderiam dificultar a leitura e manutenção do código.
Em vez de usar estruturas complexas para resolver problemas simples, optei por métodos claros e bem definidos, facilitando a compreensão do fluxo do sistema.

🔄 SRP (Single Responsibility Principle)
Princípio da Responsabilidade Única: Cada classe e método foi desenvolvido para cumprir uma única função. Seguindo o SRP, evitei que uma mesma classe tivesse várias responsabilidades. Isso facilita a manutenção e a evolução do código, além de tornar o sistema mais modular.

📜 Código Autodocumentado
Nomes Claros e Significativos: Um ponto importante de Clean Code é o código falar por si só. Utilizei nomes de variáveis, métodos e classes que expressam claramente o que fazem. Isso reduz a necessidade de comentários excessivos e facilita a leitura para outros desenvolvedores.

🌱 YAGNI (You Aren't Gonna Need It)
Evite Funcionalidades Desnecessárias: Fui cuidadosa para não implementar funcionalidades que "poderiam ser úteis no futuro", mas que não eram necessárias no momento. O foco foi construir o que era essencial para o funcionamento do sistema, evitando desperdícios de tempo e recursos.

🔄 Refatoração Constante
Melhoria Contínua do Código: Refatorei o código sempre que necessário para mantê-lo limpo, eficiente e fácil de entender. Isso incluiu melhorar a legibilidade, reduzir a complexidade e garantir a consistência em todo o sistema.

---

## 📞 Contato
Para dúvidas ou mais informações, entre em contato pelo e-mail: [danibbassetto@hotmail.com](mailto:danibbassetto@hotmail.com).
