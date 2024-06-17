import { isNil } from "lodash";
import { Nullable } from "../../shared/global";

export class Maybe<T> {
    value: Nullable<T>;

    constructor(value: Nullable<T>) {
        this.value = value;
    }

    get hasValue() {
        return !isNil(this.value);
    }

    static from<T>(value: T) {
        return value instanceof Maybe ? value : new Maybe(value);
    }

    static nothing<T>() {
        return new Maybe(null as T);
    }

    map<TResult>(selector: (value: T) => Maybe<TResult>): Maybe<TResult> {
        if(!this.hasValue) {
            return Maybe.nothing();
        }

        const result = selector(this.value!);

        return result instanceof Maybe ? result : Maybe.from(result);
    }

    async mapAsync<TResult>(selector: (value: T) => Promise<Maybe<TResult>>): Promise<Maybe<TResult>> {
        if(!this.hasValue) {
            return Maybe.nothing();
        }

        const result = await selector(this.value!);

        return result instanceof Maybe ? result : Maybe.from(result);
    }

    or(fallbackValue: Nullable<T>): Nullable<T> {
        return this.hasValue ? this.value! : fallbackValue;
    }

    do(action: (value: T) => void) {
        if(this.hasValue) {
            action(this.value!);
        }
        
        return this;
    }

    async doAsync(action: (value: T) => Promise<void>) {
        if(this.hasValue) {
            action(this.value!);
        }

        return this;
    }
}