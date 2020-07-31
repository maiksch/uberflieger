import { RequestHandler, Request, Response } from 'express';
import { LessonService } from '@application/lessons';
import * as fs from 'fs';
import * as mime from 'mime';
import { pipe } from 'fp-ts/lib/function';
import { respond } from '../common/respond';

const create: RequestHandler = async (req, res) => {
  await pipe(LessonService.create(req.body), respond(res));
};

const getList: RequestHandler = async (req, res) => {
  await pipe(LessonService.getList(), respond(res));
};

const getOne: RequestHandler = async (req, res) => {
  await pipe(LessonService.getOne(+req.params.id), respond(res));
};

const update: RequestHandler = async (req, res) => {
  await pipe(LessonService.update(req.body), respond(res));
};

const remove: RequestHandler = async (req, res) => {
  await pipe(LessonService.remove(+req.params.id), respond(res));
};

const streamVideo: RequestHandler = async (req, res) => {
  // const lektionId = +req.params.id;
  // const lektion = await LessonService.getOne(lektionId);
  // const contentType = mime.getType(lektion.video);
  // const stat = fs.statSync(lektion.video);
  // const fileSize = stat.size;
  // let range = req.headers.range;
  // if (range) {
  //   range = Array.isArray(range) ? range.join() : range;
  //   const parts = range.replace(/bytes=/, '').split('-');
  //   const start = parseInt(parts[0], 10);
  //   const end = parts[1] ? parseInt(parts[1], 10) : fileSize - 1;
  //   const chunksize = end - start + 1;
  //   const file = fs.createReadStream(lektion.video, { start, end });
  //   const head = {
  //     'Content-Range': `bytes ${start}-${end}/${fileSize}`,
  //     'Accept-Ranges': 'bytes',
  //     'Content-Length': chunksize,
  //     'Content-Type': contentType,
  //   };
  //   res.writeHead(206, head);
  //   file.pipe(res);
  // } else {
  //   const head = {
  //     'Content-Length': fileSize,
  //     'Content-Type': contentType,
  //   };
  //   res.writeHead(200, head);
  //   fs.createReadStream(lektion.video).pipe(res);
  // }
};

const LessonController = {
  getList,
  getOne,
  create,
  remove,
  update,
  streamVideo,
};

export default LessonController;
