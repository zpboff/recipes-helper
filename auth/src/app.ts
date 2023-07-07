import Fastify, { FastifyServerOptions } from 'fastify'
import { useLoginRoute } from './routes/login';
import { useRegistrationRoute } from './routes/registration';

export type AppOptions = Partial<FastifyServerOptions>;

async function buildApp(options: AppOptions = {}) {
  const fastify = Fastify(options);

  useLoginRoute(fastify);
  useRegistrationRoute(fastify);

  return fastify;
}

export { buildApp }