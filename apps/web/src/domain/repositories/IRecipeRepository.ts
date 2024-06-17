import { Maybe } from "@/core/utils/maybe";
import { Recipe } from "../models/recipe/model";

export interface IRecipeRepository {
    getRecipe: (id: string) => Promise<Maybe<Recipe>>;
    getRecipes: (page: number) => Promise<Maybe<Recipe[]>>;
    createRecipe: (recipe: Recipe) => Promise<Maybe<string>>;
    updateRecipe: (recipe: Recipe) => Promise<Maybe<boolean>>;
    deleteRecipe: (id: string) => Promise<Maybe<boolean>>;
}