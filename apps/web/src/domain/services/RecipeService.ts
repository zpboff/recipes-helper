import { Recipe } from "../models/recipe/model";
import { IRecipeService } from "../models/recipe/service";
import { IRecipeRepository } from "../repositories/IRecipeRepository";
import { Maybe } from "@/shared/maybe";

const createRecipe = async (repository: IRecipeRepository, recipe: Recipe) => {
    const recipeId = repository.createRecipe(recipe);

    return recipeId;
}

const updateRecipe = async (repository: IRecipeRepository, recipe: Recipe): Promise<Maybe<boolean>> => {
    return Maybe.from(recipe).mapAsync(async r => {        
        const existedRecipe = await repository.getRecipe(recipe.id);
        return await existedRecipe.mapAsync<boolean>(async () => await repository.updateRecipe(r));
    });
}

const deleteRecipe = async (repository: IRecipeRepository, recipeId: string) => {
    return Maybe.from(recipeId).mapAsync(async (id: string) => {        
        const existedRecipe = await repository.getRecipe(id);
        return existedRecipe.mapAsync<boolean>(() => repository.deleteRecipe(id));
    });
}

export const recipeService: IRecipeService = {
    createRecipe,
    deleteRecipe,
    updateRecipe
}