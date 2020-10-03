using System;
using System.Linq;

namespace backend.Business
{
    public class ClienteBusiness
    {
        Database.ClienteDatabase db = new Database.ClienteDatabase();
        public Models.TbCliente Consultar(int id)
        {
            Models.TbCliente login = db.ConsultarLogin(id);
            if(login == null) throw new ArgumentException("ID incorreto");
            return db.ConsultarLogin(login.IdLogin);
        }

       public Models.TbCliente Cadastrar(Models.TbCliente client, string email, string senha)
        {
            Console.WriteLine($"{email}{senha}{client.DsImagem}");
            if(string.IsNullOrEmpty(client.DsEndereco)) throw new ArgumentException("Adicione um endereço");

           Models.teste_driveContext ctx = new Models.teste_driveContext();
            if((DateTime.Now.Year - client.DtNascimeto.Value.Year) < 18) throw new ArgumentException("Menor de idade não pode fazer cadastro");

            if(string.IsNullOrEmpty(client.NmCliente)) throw new ArgumentException("Nome do cliente está nulo");

            Func<string,bool> r = (a) => {
                int cont = 0;
                foreach(char u in a)
                {
                    if(u == ' ') cont += 1;
                }
                return cont < 2;
            };

            if(db.ConsultarTodos().Any(x => x.NmCliente.ToLower() == client.NmCliente.ToLower())) throw new ArgumentException("Nome ja existe. Tente outro");

            if(r(client.NmCliente)) throw new ArgumentException("Colocar nome completo");

            if(db.ConsultarTodos().Any(x => x.DsCpf == client.DsCpf)) throw new ArgumentException("CPF já existe.");

            if(client.DsTelefone.Replace("-","").Length != 11) throw new ArgumentException("Numero de telefone inválido");

            if(client.DsCelular.Replace("-","").Length != 11) throw new ArgumentException("Numero de celular inválido");

            if(client.NrResidencia == 0) throw new ArgumentException("Numero de residencia invalido");

            if(client.DsCpf.Replace("-","").Length != 11) throw new ArgumentException("CPF invalido");

            if(client.DsCnh.Replace("-","").Length != 11) throw new ArgumentException("CNH invalido");

            Console.WriteLine("Validar senha");
            this.Seem(senha,email);

            Console.WriteLine("Validado");

            return db.Cadastrar(client,senha,email);
        }

        public Models.TbCliente Deletar(int id)
        {
            Models.TbCliente cliente = db.ConsultarCliente(id);

            if(cliente ==  null) throw new ArgumentException("Cliente não existe");
            return db.Deletar(cliente);
        }

        public void Seem(string senha, string email)
        {
            if(string.IsNullOrEmpty(email)) throw new ArgumentException("Email está vazio");
            Console.WriteLine("Validar email");
             
            if(db.ConsultarTodos().FirstOrDefault(x => x.IdLoginNavigation.DsEmail == email) != null) throw new ArgumentException("Email já existe. Tente outro");
            Console.WriteLine("Termino de Validar email");

            if(string.IsNullOrEmpty(senha)) throw new ArgumentException("Senha está vazio"); 

            if(!(email.ToLower().Contains(".com"))) throw new ArgumentException("Email inválido");

            if(!(email.ToLower().Contains("@gmail") 
                    || email.ToLower().Contains("@outlook")
                    || email.ToLower().Contains("@hotmail"))) throw new ArgumentException("Email inválido");
            
            Func<string, bool> senhaForte = ValidarSenha.SenhaForte();

            if(!(senhaForte(senha) && senha.Length >= 8)) throw new ArgumentException("Senha fraca. Tente outra senha");

            Console.WriteLine("Validou email e senha");
        }
    }
}