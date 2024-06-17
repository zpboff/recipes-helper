import { Maybe } from "@/core/utils/maybe";
import { Recipe } from "../models/recipe/model";

export interface ISearchRecipeRepository {
    search: (query: string) => Promise<Maybe<Recipe[]>>;
}