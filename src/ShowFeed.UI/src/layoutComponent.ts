import './layoutComponent.css';
import * as m from 'mithril';

const LayoutComponent: m.FactoryComponent<any> = function () {
  return {
    view: render
  };

  function render(vnode: m.Vnode<any>) {
    return [
      m('header', { class: 'header' }, [
        m('a', { class: 'brand', href: '/', oncreate: m.route.link }, 'ShowFeed'),
        m('ul', { class: 'nav-bar' }, [
          m('li', { class: 'nav-item' }, renderLink('/series', 'Series')),
          m('li', { class: 'nav-item' }, renderLink('/follows', 'Following')),
        ])
      ]),
      m('main', { class: 'main' }, vnode.children)
    ];
  }
};

function renderLink(href: string, text: string): m.Vnode {
  var attributes = {
    class: 'nav-link',
    href: href,
    oncreate: m.route.link,
  };

  if (m.route.get().indexOf(href) === 0) {
    attributes.class += ' nav-link-active';
  }

  return m('a', attributes, text);
}

export default LayoutComponent;