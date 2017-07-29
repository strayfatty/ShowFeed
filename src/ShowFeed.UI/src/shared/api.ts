import * as m from 'mithril';

export default class Api {
  static get<T>(url: string, query?: any): Promise<T> {
    return m.request<T>(createUrl(url, query), { method: 'GET' });
  }
}

function createUrl(url: string, query?: any): string {
  return 'api/' + url + createQuery(query);
}

function createQuery(query?: any): string {
  var keys = Object.keys(query || { });
  if (keys.length === 0) {
    return '';
  }

  return '?' + keys
    .map(key => toQueryParam(key, query[key]))
    .filter(element => !!element)
    .join('&');
}

function toQueryParam(key: string, value: any): string {
  if (!key || value == null) {
    return null;
  }

  return encodeURIComponent(key) + '=' +encodeURIComponent(value);
}