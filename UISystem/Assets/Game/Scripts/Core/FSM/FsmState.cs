using System.Threading.Tasks;

public abstract class FsmState
{
    protected readonly Fsm fsm;
    public FsmState(Fsm fsm)
    {
        this.fsm = fsm;
    }
    public async virtual Task Enter() { }
    public async virtual Task Exit() { }
    public virtual void Update() { }
}