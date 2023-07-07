"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.login = void 0;
const bcrypt_1 = require("bcrypt");
const jsonwebtoken_1 = require("jsonwebtoken");
const lodash_1 = require("lodash");
const nanoid_1 = require("nanoid");
async function login(request) {
    //проверяем наличие пользователя
    const user = { passwordHash: "12313" };
    if ((0, lodash_1.isNil)(user)) {
        return null;
    }
    const passwordMatched = await (0, bcrypt_1.compare)(request.password, user.passwordHash);
    if (!passwordMatched) {
        return null;
    }
    const accessToken = (0, jsonwebtoken_1.sign)(user, "");
    const refreshToken = (0, nanoid_1.nanoid)(10);
    return {
        accessToken,
        refreshToken
    };
}
exports.login = login;
