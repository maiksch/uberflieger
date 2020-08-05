import { Result } from '../results';
import {
	createLessonId,
	createLessonThumbnail,
	createModuleId,
	createString256,
	LessonId,
	LessonThumbnail,
	ModuleId,
	String256,
	VideoId,
} from '../simple-types';
import { validate } from '../validations';

export interface UnsavedLesson {
	moduleId: ModuleId;
	videoId?: VideoId;
	title: String256;
	thumbnail: LessonThumbnail;
}

export function UnsavedLesson(input: {
	title: string;
	thumbnail: string;
	moduleId: number;
}): Result<UnsavedLesson> {
	return validate({
		title: createString256(input.title),
		moduleId: createModuleId(input.moduleId),
		thumbnail: createLessonThumbnail(input.thumbnail),
	});
}

export type Lesson = UnsavedLesson & {
	id: LessonId;
};

// export type DraftedLesson = Lesson & { _type_: 'DraftedLesson' };
// export type PublishedLesson = Lesson & { _type_: 'PublishedLesson' };

export function Lesson(input: {
	id: number;
	title: string;
	thumbnail: string;
	moduleId: number;
}): Result<Lesson> {
	return validate({
		id: createLessonId(input.id),
		title: createString256(input.title),
		moduleId: createModuleId(input.moduleId),
		thumbnail: createLessonThumbnail(input.thumbnail),
	});
}

export function Lessons(input: any[]): Lesson[] {
	return input.map((i) => ({
		id: LessonId(i.id),
		title: String256(i.title),
		// video: `${__dirname}/assets/small.webm`,
		thumbnail: LessonThumbnail(i.thumbnail),
		moduleId: ModuleId(i.moduleId),
	}));
}
