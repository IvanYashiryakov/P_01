public class ReadyToDrillTransition : Transition
{
    private void Update()
    {
        if (Target == null)
            return;

        if (transform.position.x == Target.transform.position.x && transform.position.z == Target.transform.position.z + 2f)
        {
            NeedTransit = true;
        }
    }
}
