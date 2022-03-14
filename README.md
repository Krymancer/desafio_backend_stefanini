# Desafio para candidatos da Stefanini

# Requisitos:

- [x] API .NET Core
- [x] SPMD (like)
- [x] Conteinerização de todas as aplicações do projeto
- [x] Swagger
- [x] Frontend
- [x] Migration
- [ ] Deploy

# Considerações

Devido a problemas pessoas que expliquei no email so pude dedicar algumas horas no domingo. Isto contribuiu para que eu deixasse de incluir algumas features:

- [ ] Validação (Utilizando FluentValidation talvez)
- [ ] CI/CD no Github para deploy automatico
- [ ] Criar uma estrutura para a atomicidade das configurações de contraints e relações para cada entidades.

Fora isso eu não conseguir evitar que o Visual Studio mudasse a servicePort do docker o que acaba fazendo com que a API mude de porta a toda build do zero dos containers
