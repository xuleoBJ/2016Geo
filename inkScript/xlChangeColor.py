import simplestyle,inkex
		
class myEffect(inkex.Effect):
        def __init__(self):
                inkex.Effect.__init__(self)

	def effect(self):
                ## attention loop in selected.iteriems
		for id, node in self.selected.iteritems():
                    if node.attrib.has_key('style'):
                        styles = simplestyle.parseStyle(node.get('style'))
                        this_color = '#%02x%02x%02x' % (200, 200, 200)
                        styles['fill']=this_color
                        ##debug line
##                        inkex.debug(styles)
                        ##attension call simplestyle.formatstyle otherwise make bug
                        node.set('style',simplestyle.formatStyle(styles))
e = myEffect()
e.affect()
