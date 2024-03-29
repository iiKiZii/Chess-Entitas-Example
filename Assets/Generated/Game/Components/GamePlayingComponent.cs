//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity playingEntity { get { return GetGroup(GameMatcher.Playing).GetSingleEntity(); } }

    public bool isPlaying {
        get { return playingEntity != null; }
        set {
            var entity = playingEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isPlaying = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly PlayingComponent playingComponent = new PlayingComponent();

    public bool isPlaying {
        get { return HasComponent(GameComponentsLookup.Playing); }
        set {
            if (value != isPlaying) {
                var index = GameComponentsLookup.Playing;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : playingComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherPlaying;

    public static Entitas.IMatcher<GameEntity> Playing {
        get {
            if (_matcherPlaying == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Playing);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlaying = matcher;
            }

            return _matcherPlaying;
        }
    }
}
