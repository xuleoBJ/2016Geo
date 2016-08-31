import simplestyle,inkex

def draw_SVG_square((w,h), (x,y), parent):
            style = {   'stroke'        : 'none',
                        'stroke-width'  : '1',
                        'fill'          : '#055555'
                    } 
            attribs = {
                'style'     : simplestyle.formatStyle(style),
                'height'    : str(h),
                'width'     : str(w),
                'x'         : str(x),
                'y'         : str(y)
                    }
            circ = inkex.etree.SubElement(parent, inkex.addNS('rect','svg'), attribs )

def draw_SVG_path(d, parent):
            style = {   'stroke'        : '#000000',
                        'stroke-width'  : '1',
                        'fill'          : '#FF3399'
                    } 
            attribs = {
                'style'     : simplestyle.formatStyle(style),
                'd'    : str(d)
                    }
            circ = inkex.etree.SubElement(parent, inkex.addNS('path','svg'), attribs )
       
##def draw_SVG_ellipse((rx, ry), (cx, cy), parent, start_end=0,2*pi,transform=''):
##    style = {   'stroke'        : '#000000',
##                'stroke-width'  : '1',
##                'fill'          : 'none'            }
##    ell_attribs = {'style':simplestyle.formatStyle(style),
##        inkex.addNS('cx','sodipodi')        :str(cx),
##        inkex.addNS('cy','sodipodi')        :str(cy),
##        inkex.addNS('rx','sodipodi')        :str(rx),
##        inkex.addNS('ry','sodipodi')        :str(ry),
##        inkex.addNS('start','sodipodi')     :str(start_end[0]),
##        inkex.addNS('end','sodipodi')       :str(start_end[1]),
##        inkex.addNS('open','sodipodi')      :'true',    #all ellipse sectors we will draw are open
##        inkex.addNS('type','sodipodi')      :'arc',
##        'transform'                         :transform
##        
##            }
##    ell = inkex.etree.SubElement(parent, inkex.addNS('path','svg'), ell_attribs )

    #draw an SVG line segment between the given (raw) points
def draw_SVG_line( (x1, y1), (x2, y2), style, name, parent):
    line_style   = { 'stroke': style.l_col,
                     'stroke-width':str(style.l_th),
                     'fill': style.l_fill
                   }

    line_attribs = {'style' : simplestyle.formatStyle(line_style),
                    inkex.addNS('label','inkscape') : name,
                    'd' : 'M '+str(x1)+','+str(y1)+' L '+str(x2)+','+str(y2)}

    line = inkex.etree.SubElement(parent, inkex.addNS('path','svg'), line_attribs )
            
class Point:
    """ Point class represents and manipulates x,y coords. """
    def __init__(self, x=0, y=0):
        """ Create a new point at x, y """
        self.x = x
        self.y = y
	
class myEffect(inkex.Effect):
        def __init__(self):
                inkex.Effect.__init__(self)
        #SVG element generation routine
        
	def effect(self):
                ## attention loop in selected.iteriems
                currentLayer = self.current_layer
               # draw_SVG_square( (100,100),(300,300),currentLayer)
                d= "x" 
               # draw_SVG_path( d,currentLayer)
                rects = []
                points= []
                disHandle=50
		for id, node in self.selected.iteritems():
                    #inkex.debug(id)
                    if node.tag == '{http://www.w3.org/2000/svg}rect':
                        rects.append(node)
                        #inkex.debug(node.tag)
                        #inkex.debug(node.attrib['x'])
##                        x=float(node.attrib['x'])
                        #inkex.debug(node.attrib['y'])
##                        y=float(node.attrib['y'])
                        #inkex.debug(node.attrib['width'])
##                        width=float(node.attrib['width'])
                        #inkex.debug(node.attrib['height'])
##                        height=float(node.attrib['height'])
##                        points.append(Point(x+width,y+height))
##                        points.append(Point(x+width,y))
##                    inkex.debug(node)
                if len(rects) == 1:
##                    inkex.errormsg('Need at least 2 rects selected')
                    d=""
                    x1=float(rects[0].attrib['x'])
                    y1=float(rects[0].attrib['y'])
                    width1=float(rects[0].attrib['width'])
                    height1=float(rects[0].attrib['height'])
                    x2=x1+100
                    y2=y1
                    width2=width1
                    height2=height1
                    d="M "+str(x1+width1)+" "+str(y1+height1)+"v "+str(-height1) \
                                    +"h"+str(100)\
                                    +"c"+str(0)+","+str(height1)+" "+str(-height1)+","+str(height1)+" "+str(-50)+","+str(height1) \
                                    +" Z"
                    draw_SVG_path( d,currentLayer) 
                elif len(rects) == 2:
                    d=""
                    x1=float(rects[0].attrib['x'])
                    y1=float(rects[0].attrib['y'])
                    width1=float(rects[0].attrib['width'])
                    height1=float(rects[0].attrib['height'])
                    x2=float(rects[1].attrib['x'])
                    y2=float(rects[1].attrib['y'])
                    width2=float(rects[1].attrib['width'])
                    height2=float(rects[1].attrib['height'])
                   
                    if x1<x2:
                            d="M "+str(x1+width1)+" "+str(y1) \
                                    +"C"+str(x1+width1+disHandle)+","+str(y1)+" "+str(x2-disHandle)+","+str(y2)+" "+str(x2)+","+str(y2) \
                                    +"v"+str(height2) \
                                    +"C"+str(x2-disHandle)+","+str(y2+height2)+" "+str(x1+width1+disHandle)+","+str(y1+height1)+" "+str(x1+width1)+","+str(y1+height1) \
                                    +" Z"
                    else:
                            d="M "+str(x2+width2)+" "+str(y2) \
                                    +"C"+str(x2+width2+disHandle)+","+str(y2)+" "+str(x1-disHandle)+","+str(y1)+" "+str(x1)+","+str(y1) \
                                    +"v"+str(height1) \
                                    +"C"+str(x1-disHandle)+","+str(y1+height1)+" "+str(x2+width2+disHandle)+","+str(y2+height2)+" "+str(x2+width2)+","+str(y2+height2) \
                                    +" Z"
                    draw_SVG_path( d,currentLayer)    
                else:
                    pass
##                    inkex.debug("ok")
##                            return
##                    if node.attrib.has_key('style'):
##                        styles = simplestyle.parseStyle(node.get('style'))
##                        ##debug line
##                        inkex.debug(styles)
##                        ##attension call simplestyle.formatstyle otherwise make bug
##                        node.set('style',simplestyle.formatStyle(styles))
e = myEffect()
e.affect()
