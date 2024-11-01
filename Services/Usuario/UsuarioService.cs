﻿using GalaxyControl.Models;
using GalaxyControl.Repositories;
using GalaxyControl.ViewModels;
using Newtonsoft.Json;

namespace GalaxyControl.Services;

public class UsuarioService(IUsuarioRepository repository, Helpers.ISession session) : IUsuarioService
{
    private readonly IUsuarioRepository _repository = repository;
    private readonly Helpers.ISession _session = session;

    public bool Create(RegistrarUsuarioViewModel usuarioRegisterViewModel)
    {
        Usuario? usuario = _repository.GetByEmail(usuarioRegisterViewModel.Email!);

        if (usuario is not null)
            throw new Exception("Já existe um usuário com este e-mail");

        if (usuarioRegisterViewModel.Nome == "Admin")
            throw new Exception("Nome inválido! Você só pode ser um xenófago.");

        if (usuarioRegisterViewModel.Senha == usuarioRegisterViewModel.ConfirmacaoSenha)
        {
            var novoUsuario = new Usuario()
            {
                Nome = usuarioRegisterViewModel.Nome,
                Email = usuarioRegisterViewModel.Email,
                Senha = usuarioRegisterViewModel.Senha,
                DataCadastro = DateTime.Now
            };

            novoUsuario.SetHashPassword();
            _repository.Create(novoUsuario);
            return true;
        }
        else
            throw new Exception("As senhas não coincidem");
    }

    public bool Login(LoginViewModel loginViewModel)
    {
        Usuario? usuario = _repository.GetByEmail(loginViewModel.Email!);

        if (usuario is not null)
        {
            if (usuario.IsValidPassword(loginViewModel.Senha!))
            {
                _session.CreateUserSession(JsonConvert.SerializeObject(new UsuarioViewModel()
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Nome = usuario.Nome,
                    DataCadastro = usuario.DataCadastro,
                    Senha = usuario.Senha,
                    DataAlteracao = usuario.DataAlteracao
                }));
                return true;
            }
            throw new Exception("Senha incorreta. Tente novamente.");
        }
        throw new Exception("Email e/ou senha inválido(s). Tente novamente.");
    }

    public bool ExitSession()
    {
        _session.RemoveUserSession();
        return true;
    }

    public bool RedefinePassword(RedefinirSenhaViewModel redefinirSenhaViewModel)
    {
        Usuario? usuario = _session.GetUserSession();

        if (usuario is not null)
        {
            if (!usuario.IsValidPassword(redefinirSenhaViewModel.SenhaAtual!))
                throw new Exception("Senha atual incorreta");

            if (usuario.IsValidPassword(redefinirSenhaViewModel.NovaSenha!))
                throw new Exception("Nova senha deve ser diferente da senha atual");

            if (redefinirSenhaViewModel.NovaSenha != redefinirSenhaViewModel.ConfirmacaoNovaSenha)
                throw new Exception("Nova senha não coincide com a confirmação de senha");

            usuario.SetNewPassword(redefinirSenhaViewModel.NovaSenha!);
            usuario.DataAlteracao = DateTime.Now;

            _repository.Update(usuario);
            return true;
        }
        else
            throw new Exception("Usuário não encontrado");
    }

    public bool CheckActiveSession()
    {
        if (_session.GetUserSession() is not null)
            return true;
        return false;
    }
}