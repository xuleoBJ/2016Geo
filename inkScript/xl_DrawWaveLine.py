import simplestyle,inkex

def draw_SVG_square((w,h), (x,y), parent,fill= '#FF0000'):
            style = {   'stroke'        : 'none',
                        'stroke-width'  : '0.5',
                        'fill'          : fill
                    } 
            attribs = {
                'style'     : simplestyle.formatStyle(style),
                'height'    : str(h),
                'width'     : str(w),
                'x'         : str(x),
                'y'         : str(y)
                    }
            circ = inkex.etree.SubElement(parent, inkex.addNS('rect','svg'), attribs )

def draw_SVG_path(d, parent,fill= '#FF0000',strokeWidth="0.5"):
            style = {   'stroke'        : '#000000',
                        'stroke-width'  : strokeWidth,
                        'fill'          : fill
                    } 
            attribs = {
                'style'     : simplestyle.formatStyle(style),
                'd'    : str(d)
                    }
            circ = inkex.etree.SubElement(parent, inkex.addNS('path','svg'), attribs )
       
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
               # draw_SVG_path( d,currentLayer)
                #d="M50,100 C50,50 200,50 200,100 Z"
                amplitude=50
                wave=50
                startPointX=100
                startPointY=100
                d="M" + str( startPointX ) + "," + str( startPointY )
                up=1
                for i in range(20):
                    up=-1*up
                    startNewPointX=startPointX +i*wave
                    C1="C" + str(startNewPointX + 0.33 * wave)+","+ str( startPointY+ up*amplitude/2)
                    endPointX = startPointX +(i+1)*wave
                    C2=" "+str(endPointX- 0.33*wave)+","+ str( startPointY+ up*amplitude/2)
                    d+=C1
                    d+=C2
                    d+=" "+str(endPointX)+","+str(startPointY)
                draw_SVG_path( d,currentLayer) 
               # draw_SVG_path(d,currentLayer,styles['fill'],styles['stroke-width'])
e = myEffect()
e.affect()
