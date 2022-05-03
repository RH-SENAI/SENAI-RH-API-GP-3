using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;

namespace senai_gp3_webApi.Utils
{
    public static class Upload
    {
        //String de conexão que recebemos do serviço no da AZURE
        private const string STRING_DE_CONEXAO = "DefaultEndpointsProtocol=https;AccountName=armazenamentogrupo3;AccountKey=Y4K/lMSydo5BhOrGW1NdiyLYWJdqHsm6ohUG9SWvEGJeZmxWPbmjy6DrGYlJgIqn6ADyIH/gAfaKF1NgTQ391Q==;EndpointSuffix=core.windows.net";
        private const string BLOB_CONTAINER_NAME = "armazenamento-simples";

        //Permite que consigamos manipular um container
        private static BlobContainerClient BlobContainerClient { get; set; }

        static Upload()
        {
            //Permite que manipulemos um container
            BlobContainerClient = new BlobContainerClient(STRING_DE_CONEXAO, BLOB_CONTAINER_NAME);
        }


        /// <summary>
        /// Faz o upload do arquivo para o blob
        /// </summary>
        /// <param name="fotoPerfil">Arquivo vindo de um formulário</param>
        /// <returns>Nome do arquivo salvo</returns>
        public static string EnviarFoto(IFormFile fotoPerfil)
        {

            try
            {

                string[] extensoesPermitidas = { "jpg", "png", "jpeg" };


                if (fotoPerfil.Length > 0)
                {
                    //Pega a nome do IFormFile
                    var fileName = ContentDispositionHeaderValue.Parse(fotoPerfil.ContentDisposition).FileName.Trim('"');


                    //Valida a estensão 
                    if (ValidarExtensao(extensoesPermitidas, fileName))
                    {
                        var extensao = RetornarExtensao(fileName);

                        //Atribui um novo idenfificador baseado no nome do IFormFile + extensão
                        var novoNome = $"{Guid.NewGuid()}.{extensao}";

                        Console.WriteLine(novoNome);

                        //Permite que consigamos manipular um blob
                        BlobClient blobClient = BlobContainerClient.GetBlobClient(novoNome);

                        //Cria um novo block blob (arquivo)
                        blobClient.Upload(fotoPerfil.OpenReadStream());

                        return novoNome;
                    }
                    return "Extensão não permitida";
                }
                return "";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }

        /// <summary>
        /// Valida o uso de enxtensões permitidas apenas
        /// </summary>
        /// <param name="extensoes">Array de extensões permitidas</param>
        /// <param name="nomeDaFoto">Nome do arquivo</param>
        /// <returns>Verdadeiro/Falso</returns>
        public static bool ValidarExtensao(string[] extensoes, string nomeDaFoto)
        {
            string[] dados = nomeDaFoto.Split(".");
            string extensao = dados[dados.Length - 1];

            foreach (var item in extensoes)
            {
                if (extensao == item)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Remove um arquivo do servidor
        /// </summary>
        /// <param name="nomeDaFoto">Nome do Arquivo</param>
        public static void RemoverFoto(string nomeDaFoto)
        {

            //Permite que manipulemos um block blob (arquivo)
            BlobClient blobClient = BlobContainerClient.GetBlobClient(nomeDaFoto);

            blobClient.Delete();
        }


        /// <summary>
        /// Atualiza a foto de perfil
        /// </summary>
        /// <param name="nomeFotoAntiga">Nome da foto antiga</param>
        /// <param name="novaFoto">Arquivo da nova foto</param>
        /// <returns>O nome da nova foto</returns>
        public static string AtualizarFoto(string nomeFotoAntiga, IFormFile novaFoto )
        {
            try
            {
                //Remove a foto antiga
                RemoverFoto(nomeFotoAntiga);

                //Coloca a nova foto que foi inserida
                string nomeFotoAtualizada = EnviarFoto(novaFoto);

                // retorna o nome da foto com a guid
                return nomeFotoAtualizada;
            }
            catch (Azure.RequestFailedException azureExecp)
            {
                //Pega o status code da requisição
                string statusCode = azureExecp.Status.ToString();

                if (statusCode == "404")
                {
                    string nomeFotoAtualizada = EnviarFoto(novaFoto);

                    return nomeFotoAtualizada;
                }

                // Retorna o erro.
                return azureExecp.ToString();
            }
            catch (Exception exp)
            {
                return exp.ToString();
            }
        }

        /// <summary>
        /// Retorna a extensão de um arquivo
        /// </summary>
        /// <param name="nomeDoArquivo">Nome do Arquivo</param>
        /// <returns>Retorna a extensão de um arquivo</returns>
        public static string RetornarExtensao(string nomeDoArquivo)
        {
            string[] dados = nomeDoArquivo.Split('.');
            return dados[dados.Length - 1];
        }
    }
}
