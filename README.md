# GalaxyControl

**GalaxyControl** é um sistema desenvolvido em C# .NET 8 utilizando o padrão **MVC** para catalogação e acompanhamento de naves caídas e monitoramento de patos galácticos. O sistema foi implantado em uma instância EC2 da AWS, conectando-se a um banco de dados MySQL, e utiliza tecnologias modernas de front-end. O projeto faz parte do desafio DSIN CODER CHALLENGE 2024 e foi desenvolvido no período de uma semana.

---

## Tecnologias Utilizadas

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

## Funcionalidades do Sistema

### 1. Login e Registro
- **Cadastro:** Os usuários devem se registrar com um e-mail válido.
- **Redefinição de Senha:** Possibilidade de redefinir a senha em caso de esquecimento.

### 2. Catalogação de Naves
- **CRUD de Naves:** Criar, editar e excluir naves caídas.
- **Status de Reparo:** Ao criar uma nave, o status é definido como **"Aguardando"** e pode ser alterado para **"Em Andamento"** ou **"Finalizado"**. Naves com status **"Em Andamento"** ou **"Finalizado"** não podem ser editadas ou excluídas.
- **Cálculo de Tripulantes:** O número de sobreviventes é a soma dos feridos e saudáveis.
- **Código de Rastreamento:** Único por nave e não editável.
- **Salvamento Condicional:** O botão de salvar só é habilitado se todos os campos obrigatórios estiverem preenchidos e um uso futuro for definido.

#### Usos Futuros da Nave
Os usuários podem atribuir uma das seguintes classificações ao adicionar uma nave caída:

- **Sucata Espacial:** Nave muito destruída, com pouco valor tecnológico.
- **Joia Tecnológica:** Potencial tecnológico alto ou revolucionário.
- **Arsenal Alienígena:** Nave com armamento pesado.
- **Ameaça em Potencial:** Nave com grau de periculosidade crítico.
- **Fonte de Energia Alternativa:** Combustível de tecnologia alternativa.
- **Mistureba Inconclusiva:** Combina várias características.

### 3. Monitoramento de Patos Galácticos
- **Exibição:** Mostra a distância e imagens dos patos galácticos.
- **Classificação:** Imagens indicam se os patos estão sozinhos, em bando, xenófagos ou normais.
- **Estratégias de Captura:** Ao clicar em um pato, o usuário pode ver estratégias para capturar xenófagos, com base na distância e se estão em bando (total de 8 estratégias).

---

## Rodando o Projeto Localmente
Na documentação entregue, consta os dados para acessar o site através da EC2. Caso a instância EC2 não responda, siga os passos abaixo para executar o projeto localmente:

1. **Pré-requisitos:**
   - .NET SDK 8.0 ou superior
     - [Download do .NET SDK](https://dotnet.microsoft.com/pt-br/download)
   - MySQL Server
     - [Download do MySQL Server](https://dev.mysql.com/downloads/installer/)

2. **Clone o repositório:**
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd GalaxyControl
   ```

3. **Configurar a String de Conexão:**
   - Abra o arquivo `appsettings.json` e, se necessário, atualize a string de conexão para o seu banco de dados MySQL.

4. **Criar o Banco de Dados:**
   - Execute as migrations para criar o banco de dados. Abra o terminal e rode o comando:
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

## Contato
Para dúvidas ou mais informações, entre em contato pelo e-mail: [danibbassetto@hotmail.com](mailto:danibbassetto@hotmail.com).
