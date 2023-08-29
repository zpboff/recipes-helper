import { FastifyInstance } from 'fastify'
import { RegistrationRequest, registration } from '../services/registration';

export function useRegistrationRoute(fastify: FastifyInstance) {
    fastify.post('/registration', async (req, res) => {
        return await registration(req.body as RegistrationRequest);
    });
}