import { IRecipeRepository } from "@/domain/repositories/IRecipeRepository";
import { Recipe } from "./model"
import { Maybe } from "@/core/utils/maybe";

export interface IRecipeService {
    getRecipe: (repository: IRecipeRepository, id: string) => Promise<Maybe<Recipe>>;
    getRecipes: (repository: IRecipeRepository, page: number) => Promise<Maybe<Recipe[]>>;
    createRecipe: (repository: IRecipeRepository, recipe: Recipe) => Promise<Maybe<string>>;
    updateRecipe: (repository: IRecipeRepository, recipe: Recipe) => Promise<Maybe<boolean>>;
    deleteRecipe: (repository: IRecipeRepository, id: string) => Promise<Maybe<boolean>>;
}