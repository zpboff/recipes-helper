import { IRecipeRepository } from "@/domain/repositories/IRecipeRepository";
import { Recipe } from "./model"
import { Maybe } from "@/shared/maybe";

export interface IRecipeService {
    createRecipe: (repository: IRecipeRepository, recipe: Recipe) => Promise<Maybe<string>>;
    updateRecipe: (repository: IRecipeRepository, recipe: Recipe) => Promise<Maybe<boolean>>;
    deleteRecipe: (repository: IRecipeRepository, id: string) => Promise<Maybe<boolean>>;
}