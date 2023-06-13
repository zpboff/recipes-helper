import { createInputBehavior } from "@/app/utils/createInputBehavior";
import axios, { AxiosError } from "axios";
import { createEffect, createEvent, createStore, forward, sample } from "effector";
import { RecipesReadDto } from "./types";
import { client } from "@/app/core/apiClient";

const [$query, queryChanged] = createInputBehavior();

const searchSubmitted = createEvent();
const searchFx = createEffect<string, RecipesReadDto[], AxiosError>(async (query) => {
    const { data } = await client<RecipesReadDto[]>(`/searchRecipe/${query}`);

    return data;
});

sample({
    name: "Search",
    clock: searchSubmitted,
    source: $query,
    target: searchFx
});

export { $query, queryChanged, searchSubmitted }