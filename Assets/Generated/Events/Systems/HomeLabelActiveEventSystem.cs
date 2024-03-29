//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class HomeLabelActiveEventSystem : Entitas.ReactiveSystem<UiEntity> {

    readonly System.Collections.Generic.List<IHomeLabelActiveListener> _listenerBuffer;

    public HomeLabelActiveEventSystem(Contexts contexts) : base(contexts.ui) {
        _listenerBuffer = new System.Collections.Generic.List<IHomeLabelActiveListener>();
    }

    protected override Entitas.ICollector<UiEntity> GetTrigger(Entitas.IContext<UiEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(UiMatcher.HomeLabelActive)
        );
    }

    protected override bool Filter(UiEntity entity) {
        return entity.hasHomeLabelActive && entity.hasHomeLabelActiveListener;
    }

    protected override void Execute(System.Collections.Generic.List<UiEntity> entities) {
        foreach (var e in entities) {
            var component = e.homeLabelActive;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.homeLabelActiveListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnHomeLabelActive(e, component.value);
            }
        }
    }
}
