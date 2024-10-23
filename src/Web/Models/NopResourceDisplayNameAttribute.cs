namespace Web.Models
{
    internal class NopResourceDisplayNameAttribute : Attribute
    {
        private string v;

        public NopResourceDisplayNameAttribute(string v)
        {
            this.v = v;
        }
    }
}