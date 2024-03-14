import { RecipesReadDto } from "@/app/shared/api/recipes/model";
import { searchRecipe } from "@/app/shared/api/recipes/searchRecipe";
import { createInputBehavior } from "@/app/shared/ui/input";
import { AxiosError } from "axios";
import { createEffect, createEvent, sample } from "effector";

const [$query, queryChanged] = createInputBehavior();

const searchSubmitted = createEvent();
const searchFx = createEffect<string, RecipesReadDto[], AxiosError>(searchRecipe);

sample({
    name: "Search",
    clock: searchSubmitted,
    source: $query,
    target: searchFx
});

export { $query, queryChanged, searchSubmitted }