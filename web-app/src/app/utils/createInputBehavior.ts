import { Event, Store, createEvent, createStore, forward } from "effector";

export function createInputBehavior(): [Store<string>, Event<string>] {    
    const $query = createStore("");
    const queryChanged = createEvent<string>();
    forward({ from: queryChanged, to: $query });

    return [$query, queryChanged];
}