import {applyMiddleware, combineReducers} from "redux";
// import {configureStore} from 'redux-toolkit'
import { legacy_createStore as createStore} from 'redux'
import {composeWithDevTools } from 'redux-devtools-extension'
import thunk from "redux-thunk";
import userReducer from "./userReducer";
import fileReducer from "./fileReducer";


const rootReducer = combineReducers({
    user: userReducer,
    files: fileReducer,
})

export const store = createStore(rootReducer, composeWithDevTools(applyMiddleware(thunk)))