# 🛒 Lista de Compras

Sistema desenvolvido para auxiliar usuários no gerenciamento de compras domésticas, permitindo o cadastro de produtos, categorias, listas de compras e seus respectivos itens.

---

# 🤳 Demonstração

<p align="center">
    <img src="Midia/ApresentacaoMobile.gif" alt="Demonstração do sistema">
</p>

## 📖 Sobre o Projeto

Maria realiza as compras da família semanalmente, mas frequentemente esquece itens importantes ou acaba comprando produtos que já possui em casa.

Para solucionar esse problema, foi desenvolvido o **Lista de Compras**, um sistema que permite organizar produtos em categorias, criar listas de compras e controlar os itens adquiridos, facilitando o planejamento e a gestão das compras.

---

# 🚀 Funcionalidades

## 📂 Módulo de Categorias

Permite organizar os produtos por categorias.

### Funcionalidades

- ✅ Cadastrar categorias
- ✅ Editar categorias
- ✅ Excluir categorias
- ✅ Visualizar categorias cadastradas

### Regras de Negócio

| Campo | Descrição                                |
| ----- | ---------------------------------------- |
| Nome  | Texto único com até 50 caracteres        |
| Cor   | Seleção por paleta ou código hexadecimal |

**Validações**

- Não pode existir mais de uma categoria com o mesmo nome.
- Não é permitido excluir categorias que possuam produtos vinculados.

---

## 🥫 Módulo de Produtos

Responsável pelo gerenciamento dos produtos disponíveis para compra.

### Funcionalidades

- ✅ Cadastrar produtos
- ✅ Editar produtos
- ✅ Excluir produtos
- ✅ Visualizar produtos cadastrados

### Regras de Negócio

| Campo             | Descrição                      |
| ----------------- | ------------------------------ |
| Nome              | Entre 2 e 100 caracteres       |
| Categoria         | Seleção obrigatória            |
| Unidade de Medida | Kg, Unidade, Litro, Caixa, etc |
| Preço Aproximado  | Valor estimado do produto      |

**Validações**

- Não pode haver produtos com o mesmo nome dentro da mesma categoria.

---

## 📝 Módulo de Listas de Compras

Permite criar e gerenciar listas de compras.

### Funcionalidades

- ✅ Criar listas
- ✅ Editar listas
- ✅ Excluir listas
- ✅ Visualizar listas cadastradas

### Regras de Negócio

| Campo           | Descrição                |
| --------------- | ------------------------ |
| Nome da Lista   | Entre 3 e 100 caracteres |
| Data de Criação | Gerada automaticamente   |
| Status          | Aberta ou Concluída      |

**Validações**

- Não permitir excluir listas que possuam itens vinculados.
- Exibir quantidade total de itens da lista.
- Exibir valor total estimado da compra.

---

## 🛍️ Módulo de Itens da Lista

Gerencia os produtos adicionados às listas de compras.

### Funcionalidades

- ✅ Adicionar itens à lista
- ✅ Remover itens da lista
- ✅ Visualizar itens da lista
- ✅ Exibir categoria do produto selecionado

### Regras de Negócio

| Campo      | Descrição           |
| ---------- | ------------------- |
| Produto    | Seleção obrigatória |
| Quantidade | Número positivo     |

**Validações**

- Não permitir o mesmo produto duas vezes na mesma lista.
- Calcular automaticamente o valor total da lista.

### Fórmula de Cálculo

```text
Valor Total = Σ (Preço Aproximado × Quantidade)
```

---

# 📊 Estrutura do Sistema

```text
Categorias
    │
    └── Produtos
            │
            └── Itens da Lista
                    │
                    └── Lista de Compras
```

---

# 🎯 Objetivo

O sistema tem como objetivo auxiliar no planejamento de compras, proporcionando:

- Melhor organização dos produtos.
- Redução de compras duplicadas.
- Controle do valor estimado gasto.
- Facilidade na criação e manutenção de listas de compras.

---

# 🏗️ Tecnologias Utilizadas

> Adicione aqui as tecnologias utilizadas no desenvolvimento.

Exemplo:

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap
- HTML5
- CSS3
- JavaScript

---

# 👨‍💻 Equipe de Desenvolvimento

Projeto desenvolvido pelos alunos **Thiago Kovalski e Davi Andrade da Academia do Programador**.

---

# 📄 Licença

Este projeto possui fins educacionais e acadêmicos.
