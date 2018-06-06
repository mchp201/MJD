import { webaddsubmit } from '../services/webadd';

export default {
  namespace: 'webadd',

  state: {
    status: undefined,
  },

  effects: {
    *submit({ payload, callback }, { call, put }) {
        console.log("effects-submit");
        const response = yield call(webaddsubmit, payload);
        yield put({
            type: 'webaddHandle',
            payload: { status: 'ok' },
        });
        if (callback) callback();

        // yield put(
        //     routerRedux.push('/form/basic-form')
        // );
    },
  },

  reducers: {
    webaddHandle(state, { payload }) {
      return {
        ...state,
        status: payload.status,
      };
    },
  },
};
