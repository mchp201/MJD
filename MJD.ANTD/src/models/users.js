import { queryUsers, addUsers } from '../services/users';
import { routerRedux } from 'dva/router';

export default {
  namespace: 'users',

  state: {
    data: {
      list: [],
      pagination: {},
    },
  },

  effects: {
    *fetch({ payload }, { call, put }) {
        const response = yield call(queryUsers, payload);
        yield put({
            type: 'save',
            payload: response,
        });
    },
    *add({ payload, callback }, { call, put }) {
        console.log("effects-add");
        const response = yield call(addUsers, payload);
        yield put({
            type: 'save',
            payload: response,
        });
        if (callback) callback();

        // yield put(
        //     routerRedux.push('/form/basic-form')
        // );
    },
  },

  reducers: {
    save(state, action) {
      return {
        ...state,
        data: action.payload,
      };
    },
  },
};
