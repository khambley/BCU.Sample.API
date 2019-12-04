
namespace BCU.Sample.API
{
    public interface IComponent
    {
        string Name { get; }
    }

    public class ComponentA
    {
        private readonly IComponent _componentB;

        public ComponentA(IComponent componentB)
        {
            this._componentB = componentB;
        }
    }

    public class ComponentB : IComponent
    {
        public string Name { get; set; } = nameof(ComponentB);
    }
    // this is the tightly-coupled version
    //public class ComponentA
    //{
    //    private readonly ComponentB _componentB;

    //    public ComponentA()
    //    {
    //        this._componentB = new ComponentB();
    //    }
    //}

    //public class ComponentB
    //{
    //    public string Name { get; set; }

    //}
}
