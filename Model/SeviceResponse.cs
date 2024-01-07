namespace WebApi.Model
{
    public class SeviceResponse<T>
    {
        public T? Dados {  get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}
