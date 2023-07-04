"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.buildApp = void 0;
const fastify_1 = __importDefault(require("fastify"));
const login_1 = require("./login");
const registration_1 = require("./registration");
async function buildApp(options = {}) {
    const fastify = (0, fastify_1.default)(options);
    (0, login_1.useLoginRoute)(fastify);
    (0, registration_1.useRegistrationRoute)(fastify);
    return fastify;
}
exports.buildApp = buildApp;
