# Guardian Grid – Painel Administrativo Web (ASP.NET Core MVC)

Este projeto faz parte do Global Solution 2025, com foco em mitigar os impactos da falta de energia causada por eventos climáticos extremos. O Painel Administrativo Web foi desenvolvido em C# com ASP.NET Core MVC e visa fornecer suporte à gestão e monitoramento de eventos em tempo real.

---

##  Funcionalidades Implementadas

1. **Login de administrador** (com sessão)
2. **Cadastro de eventos** (com validação e tratamento de erros)
3. **Geração de alertas por região**
4. **Visualização de estatísticas em gráfico** (Chart.js)
5. **Exportação de relatórios em CSV**
6. **Verificação automática de zonas críticas** (regiões com ≥ 3 eventos recentes)

---

##  Tecnologias Utilizadas

* ASP.NET Core MVC (.NET 6)
* Entity Framework Core + SQLite
* Bootstrap 5
* Chart.js
* CsvHelper
* Sessão para autenticação manual

---

##  Como Executar Localmente

1. Clone o repositório:

   ```bash
   git clone https://github.com/seuusuario/guardian-grid-admin.git
   ```
2. Abra no Visual Studio 2022+
3. Rode as migrations:

   ```bash
   Add-Migration Init
   Update-Database
   ```
4. Pressione F5 ou clique em "Iniciar"
5. Acesse `https://localhost:{porta}/Auth/Login`

> Login padrão:
>
> * Usuário: `admin`
> * Senha: `123456`

---

##  Exemplo de Uso

* Acesse a área de eventos para registrar ocorrências
* Gere alertas em tempo real para regiões afetadas
* Exporte relatórios para análise externa (CSV)
* Consulte gráficos para apoio à decisão
* Verifique zonas com alto nível de risco

---

##  Estrutura do Projeto

```
GuardianGrid.AdminPanel/
├── Controllers/
│   ├── AuthController.cs
│   ├── EventosController.cs
│   ├── AlertasController.cs
│   └── DashboardController.cs
├── Models/
│   ├── Evento.cs
│   ├── Alerta.cs
│   ├── UsuarioLoginViewModel.cs
│   └── GuardianGridContext.cs
├── Views/
│   ├── Auth/
│   ├── Eventos/
│   ├── Alertas/
│   └── Dashboard/
├── wwwroot/
├── appsettings.json
├── Program.cs
└── README.md
```

---

##  Contribuição

Este projeto foi desenvolvido para fins educacionais e pode ser expandido com:

* Autenticação com Identity
* Upload de arquivos e imagens
* Integração com banco de dados externo
* API REST para consumo externo

---

##  Entrega

Entrega referente à disciplina de **C# Software Development** da FIAP (3º Ano - Engenharia de Software).

**Alunos:** Julio Zampieri, Lucas Carlos, João Gabriel
<br>
**Projeto:** Guardian Grid
