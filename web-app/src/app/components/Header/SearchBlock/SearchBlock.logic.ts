import { createInputBehavior } from "@/app/utils/createInputBehavior";
import { createEffect, createEvent, createStore, forward, sample } from "effector";

const [$query, queryChanged] = createInputBehavior();

const searchSubmitted = createEvent();
const searchFx = createEffect<string, void>(async (query) => {
    console.log(query);
});

sample({
    name: "Search",
    clock: searchSubmitted,
    source: $query,
    target: searchFx
});

export { $query, queryChanged, searchSubmitted }