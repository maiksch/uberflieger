import * as cors from 'cors';
import * as express from 'express';
import * as morgan from 'morgan';
import { environment } from './environments/environment';
import router from './router';

(async () => {
  console.log('[INFO] Starting up API...💯🤙');
  express()
    .use(cors())
    .use(express.json())
    .use(morgan('combined'))
    .use(router())
    .listen(environment.port, environment.host, () => {
      console.log(
        `[INFO] Listening to ${environment.host}:${environment.port}`
      );
    });
})();
